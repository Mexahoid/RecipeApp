using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using DoubleList = System.Collections.Generic.List<System.Tuple<string, string>>;
using TripleDoubleList = System.Collections.Generic.List<System.Tuple<System.Tuple<string, string>, System.Tuple<string, string>, System.Tuple<string, string>>>;

namespace RecipeApp.Controllers
{
    class PersistenceController
    {
        public enum DoubleLists
        {
            Type,
            Kitchen,
            Device
        }


        public Tuple<string, string> RecipeName { get; set; }

        public string RecipeText { get; set; }

        public string RecipeLink { get; set; }

        public string RecipeType { get; set; }

        public string RecipeKitchen { get; set; }

        public TripleDoubleList Ingreds { get; set; }

        public DoubleList RecipeSpecificDevices { get; set; }


        public void PersistRecipe()
        {
            PersistRecipeSpecificDevices();
            PersistRecipeSpecificIngredients();
            if (string.IsNullOrEmpty(RecipeName.Item1))
                Connector.GetTable(QueryFactory.Queries.DeleteRecipe,
                    Tuple.Create("@Name", RecipeName.Item2));
            else if (!string.IsNullOrEmpty(RecipeName.Item1) &&
                     !string.IsNullOrEmpty(RecipeName.Item2))
                Connector.GetTable(QueryFactory.Queries.UpdateRecipePrimaryData,
                    Tuple.Create("@Name", RecipeName.Item1),
                    Tuple.Create("@Desc", RecipeText),
                    Tuple.Create("@Link", RecipeLink),
                    Tuple.Create("@Type", RecipeType),
                    Tuple.Create("@Kitch", RecipeKitchen),
                    Tuple.Create("@Old", RecipeName.Item2));
            else
                Connector.GetTable(QueryFactory.Queries.InsertRecipe,
                    Tuple.Create("@Name", RecipeName.Item1),
                    Tuple.Create("@Desc", RecipeText),
                    Tuple.Create("@Link", RecipeLink),
                    Tuple.Create("@Type", RecipeType),
                    Tuple.Create("@Kitch", RecipeKitchen));
        }

        private void PersistRecipeSpecificDevices()
        {
            foreach (var device in RecipeSpecificDevices)
            {
                if (string.IsNullOrEmpty(device.Item2))
                    Connector.GetTable(QueryFactory.Queries.InsertDeviceToRecipe,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@DeviceName", device.Item1));
                else if(string.IsNullOrEmpty(device.Item1))
                    Connector.GetTable(QueryFactory.Queries.DeleteDeviceFromRecipeByNames,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@DeviceName", device.Item2));

            }
        }

        private void PersistRecipeSpecificIngredients()
        {
            foreach (var tuple in Ingreds)
            {
                if (tuple.Item1.Item2 == string.Empty)
                {
                    Connector.GetTable(QueryFactory.Queries.InsertIngredientToRecipe,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@IngredName", tuple.Item1.Item1),
                        Tuple.Create("@Quantity", tuple.Item2.Item1),
                        Tuple.Create("@Units", tuple.Item3.Item1));
                }
                else if (tuple.Item1.Item1 == string.Empty)
                {
                    Connector.GetTable(QueryFactory.Queries.DeleteIngredientFromRecipe,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@IngredName", tuple.Item1.Item2));
                }
                else if(tuple.Item1.Item1 != tuple.Item1.Item2 ||
                        tuple.Item2.Item1 != tuple.Item2.Item2 ||
                        tuple.Item3.Item1 != tuple.Item3.Item2)
                {
                    Connector.GetTable(QueryFactory.Queries.DeleteIngredientFromRecipe,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@IngredName", tuple.Item1.Item2));

                    Connector.GetTable(QueryFactory.Queries.InsertIngredientToRecipe,
                        Tuple.Create("@RecipeName", RecipeName.Item2),
                        Tuple.Create("@IngredName", tuple.Item1.Item1),
                        Tuple.Create("@Quantity", tuple.Item2.Item1),
                        Tuple.Create("@Units", tuple.Item3.Item1));

                }
            }
        }
        
        public void DoubleListPersister(DoubleList list, DoubleLists type)
        {
            if (list == null)
                return;
            QueryFactory.Queries queryInsert = 0;
            QueryFactory.Queries queryUpdate = 0;

            switch (type)
            {
                case DoubleLists.Device:
                    queryInsert = QueryFactory.Queries.InsertDevice;
                    queryUpdate = QueryFactory.Queries.UpdateDevice;
                    break;
                case DoubleLists.Kitchen:
                    queryInsert = QueryFactory.Queries.InsertKitchen;
                    queryUpdate = QueryFactory.Queries.UpdateKitchen;
                    break;
                case DoubleLists.Type:
                    queryInsert = QueryFactory.Queries.InsertType;
                    queryUpdate = QueryFactory.Queries.UpdateType;
                    break;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 != string.Empty && list[i].Item2 == string.Empty)
                {
                    Connector.GetTable(queryInsert,
                        Tuple.Create("@Name", list[i].Item1));
                    list[i] = Tuple.Create(list[i].Item1, list[i].Item1);
                    continue;
                }
                if (list[i].Item1 != list[i].Item2)
                {
                    Connector.GetTable(queryUpdate,
                        Tuple.Create("@New", list[i].Item1),
                        Tuple.Create("@Old", list[i].Item2));
                    list[i] = Tuple.Create(list[i].Item1, list[i].Item1);
                }
            }
        }
        
        public void PersistIngredsChanges(DoubleList list)
        {
            foreach (var tuple in list)
            {
                if (tuple.Item2 == string.Empty)
                {
                    Connector.GetTable(QueryFactory.Queries.InsertIngred,
                        Tuple.Create("@Name", tuple.Item1));
                } else
                if (tuple.Item1 != tuple.Item2)
                {
                    Connector.GetTable(QueryFactory.Queries.UpdateIngredByName,
                        Tuple.Create("@Name", tuple.Item1),
                        Tuple.Create("@Old", tuple.Item2));
                    for (int i = 0; i < Ingreds.Count; i++)
                    {
                        if (Ingreds[i].Item1.Item2 != tuple.Item2)
                            continue;
                            Ingreds[i] = new Tuple<
                                Tuple<string, string>,
                                Tuple<string, string>,
                                Tuple<string, string>>(
                                Tuple.Create(Ingreds[i].Item1.Item1, tuple.Item1), Ingreds[i].Item2, Ingreds[i].Item3);
                        break;
                    }
                }
            }
        }

    }
}
