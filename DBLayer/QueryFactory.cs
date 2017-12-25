using System;

namespace DBLayer
{
    public class QueryFactory
    {
        public enum Queries
        {
            QuerySelectRecipeNames,
            QueryViewerSelectIngreds,
            QueryViewerSelectDevices,
            QueryViewerSelectMiscData,

            SelectKitchenByRecipeName,
            QueryRedactorSelectDevices,
            QueryRedactorSelectTypes,
            
            InsertKitchen,
            QueryRedactorInsertNewDevice,
            QueryRedactorInsertNewType,

            QueryRedactorInsertIngreds,
            QueryRedactorSelectPureIngreds,
            SelectAllKitchens,
            UpdateKitchen,



            DeleteRecipeByName,
            UpdateRecipeByName,




            SelectLinkByRecipeName,
            SelectTextByRecipeName,

            SelectTypeByRecipeName,
            SelectAllTypes,
            InsertType,
            UpdateType
        }

        private readonly string[] _queries;

        public QueryFactory()
        {
            _queries = new []
            {
                "Select Name From Recipe",      //Основной вывод названий рецептов

                "SELECT I.Name AS 'Название', RI.Quantity AS 'Количество', I.Units AS 'Единицы измерения'" +
                " FROM RecipeIngredient AS RI" +
                " LEFT JOIN Recipe AS R ON R.ID = RI.IDRecipe" +
                " LEFT JOIN Ingredient AS I ON I.ID = RI.IDIngred" +
                " WHERE R.Name = @Name",            //Вывод списка ингредиентов для первой вкладки

                "SELECT Name " +
                "FROM Device " +
                "WHERE ID " +
                " IN (SELECT IDDevice " +
                "FROM RecipeDevice " +
                "WHERE IDRecipe = " +
                "(SELECT ID " +
                "FROM Recipe " +
                "WHERE Name = @Name))",             //Вывод списка устройств для данного рецепта на первой вкладке

                "SELECT R.[Description], R.[Link], T.[Name], K.[Name] " +
                " FROM [Recipe] AS R" +
                " LEFT JOIN [Type] AS T ON T.ID = R.IDType" + 
                " LEFT JOIN [Kitchen] AS K ON K.ID = R.IDKitchen" +
                " WHERE R.Name = @Name",            //Вывод MiscData для рецепта на первой вкладке

                "SELECT Name FROM Kitchen WHERE Id = (SELECT IDKitchen FROM Recipe WHERE Name = @Name)",

                "SELECT Name FROM Device",

                "SELECT Name FROM Type",

                "INSERT INTO Kitchen VALUES (@Name)",

                "INSERT INTO Device VALUES (@Name)",

                "INSERT INTO Type VALUES (@Name)",

                "INSERT INTO Ingredient VALUES (@Name, @Units)",

                "SELECT [Name] AS 'Название', [Units] AS 'Единицы измерения' FROM Ingredient",

                "SELECT Name FROM Kitchen ORDER BY Name",

                "UPDATE Kitchen SET Name = @New WHERE Name = @Old",

                "DELETE FROM Recipe WHERE Name = @Name",

                "UPDATE Recipe SET Name = @New WHERE Name = @Old",

                "SELECT Link FROM Recipe WHERE Name = @Name",

                "SELECT Description FROM Recipe WHERE Name = @Name",

                "SELECT Name FROM Type WHERE Id = (SELECT IDType FROM Recipe WHERE Name = @Name)",

                "SELECT Name FROM Type",

                "INSERT INTO Type VALUES (@Name)",

                "UPDATE Type SET Name = @New WHERE Name = @Old",
            };
        }

        private string[] quers =
        {
            "SELECT Name FROM Recipe",

            "INSERT INTO Recipe (Name, Description, Link, IDType, IDKitchen) VALUES " +
            "(@Name, @Desc, @Kink, @IdType, @IdKit)"
        };

        public string GetQuery(Queries q)
        {
            return _queries[(int) q];
        }
    }
}
