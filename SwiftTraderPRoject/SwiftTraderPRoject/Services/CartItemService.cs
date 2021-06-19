using SQLite;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Services
{
    public class CartItemService
    {
        SQLiteConnection sqlService = DependencyService.Get<ISqlite>().GetConnection();
        public int GetUserCartCount()
        {
            var counter = sqlService.Table<CartItem>().Count();
            sqlService.Close();
            return counter;
        }

        public void RemoveItemsFromCart()
        {
            sqlService.DeleteAll<CartItem>();
            sqlService.Commit();
            sqlService.Close();
        }
    }
}
