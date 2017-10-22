using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class DataFiller
    {
        internal enum Queries
        {
            QuerySelectRecipeNames,
            QueryViewerSelectIngreds,
            QueryViewerSelectDevices,
            QueryViewerSelectMiscData,
            
            QueryRedactorSelectKitchens,
            QueryRedactorSelectDevices,
            QueryRedactorSelectTypes
        }

        private readonly string[] _queries;

        public DataFiller()
        {
            _queries = new []
            {
                "Select Name From Recipe",      //Основной вывод названий рецептов

                "SELECT I.[Name] AS 'Название', RI.[Quantity] AS 'Количество', I.[Units] AS 'Единицы измерения'" +
                " FROM [RecipeIngredient] AS RI" +
                " LEFT JOIN [Recipe] AS R ON R.ID = RI.IDRecipe" +
                " LEFT JOIN [Ingredient] AS I ON I.ID = RI.IDIngred" +
                " WHERE R.Name = '",            //Вывод списка ингредиентов для первой вкладки

                "SELECT [Name] " +
                "FROM [Device] " +
                "WHERE ID " +
                " IN (SELECT [IDDevice] " +
                "FROM [RecipeDevice] " +
                "WHERE [IDRecipe] = " +
                "(SELECT [ID] " +
                "FROM [Recipe] " +
                "WHERE [Name] = '",             //Вывод списка устройств для данного рецепта на первой вкладке

                "SELECT R.[Description], R.[Link], T.[Name], K.[Name] " +
                " FROM [Recipe] AS R" +
                " LEFT JOIN [Type] AS T ON T.ID = R.IDType" +
                " LEFT JOIN [Kitchen] AS K ON K.ID = R.IDKitchen" +
                " WHERE R.Name = '",            //Вывод MiscData для рецепта на первой вкладке

                "",

                "",

                "",

                //Окончания строк

                "",

                "'",

                "')) ",

                "'",

                "",

                "",

                ""

            };
        }


        public Tuple<string, string> GetQuery(Queries q)
        {
            return Tuple.Create(_queries[(int)q], _queries[(int)q + 7]);
        }
    }
}
