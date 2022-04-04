using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Api.Models;

namespace Api.Database
{
    public class DataConect
    {
        #region Create-Table-DbPath
        readonly SQLiteAsyncConnection _database;

        public DataConect(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            #region Create-Tables
            _database.CreateTableAsync<UserModel>().Wait();
            _database.CreateTableAsync<PersonModel>().Wait();
            _database.CreateTableAsync<ProductModel>().Wait();
            #endregion
        }
        #endregion

        #region CRUD-USER TABLE
        /* METODO SELECT SEARCH BAR()*/
        public Task<UserModel> GetUserModelAsynsc(int id)
        {
            return _database.Table<UserModel>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }

        /* METODO SELECT ()*/ 
        public Task<List<UserModel>> GetUserModel()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        /* METODO GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SaveUserModelAsync(UserModel userModel)
        {
            if (userModel.UserID != 0)
            {
                return _database.UpdateAsync(userModel);
            }
            else
            {
                return _database.InsertAsync(userModel);
            }
        }

        /* METOD-O ELIMINAR () */
        public Task<int> DeleteUserModelAsync(UserModel userModel)
        {
            return _database.DeleteAsync(userModel);
        }

        public Task<List<UserModel>> GetUsersValidate(string email, string password)
        {
            return _database.QueryAsync<UserModel>("SELECT * FROM UserModel WHERE EmailField = '" + email + "' AND PasswordField = '" + password + "'");
        }

        

        #endregion

        #region CRUD-PROD-TABLE
        public Task<List<ProductModel>> GetProValidate(string numero, string nombrepro)
        {
            return _database.QueryAsync<ProductModel>("SELECT * FROM ProductModel WHERE Numero = '" + numero + "' AND NombrePro = '" + nombrepro + "'");
        }

        public Task<int> SaveProdModelAsync(ProductModel productModel)
        {
            if (productModel.ProdID != 0)
            {
                return _database.UpdateAsync(productModel);
            }
            else
            {
                return _database.InsertAsync(productModel);
            }
        }

        public Task<ProductModel> GetProductModelAsynsc(int id)
        {
            return _database.Table<ProductModel>()
                            .Where(i => i.ProdID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<List<ProductModel>> GetProdModel()
        {
            return _database.Table<ProductModel>().ToListAsync();
        }
        #endregion

        #region CRUD - PERSON TABLE
        public Task<PersonModel> GetPersonModelAynsc(int id)
        {
            return _database.Table<PersonModel>()
                            .Where(i => i.PersonID == id)
                            .FirstOrDefaultAsync();
        }

        /* METOD-O SELECT ()*/
        public Task<List<PersonModel>> GetPersonModel()
        {
            return _database.Table<PersonModel>().ToListAsync();
        }

        /* METOD-O GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SavePersonModelAsync(PersonModel personModel)
        {
            if (personModel.PersonID != 0)
            {
                return _database.UpdateAsync(personModel);
            }
            else
            {
                return _database.InsertAsync(personModel);
            }
        }

        /* METOD-O ELIMINAR () */
        public Task<int> DeletePersonModelAsync(PersonModel personModel)
        {
            return _database.DeleteAsync(personModel);
        }
        #endregion
    }
}
