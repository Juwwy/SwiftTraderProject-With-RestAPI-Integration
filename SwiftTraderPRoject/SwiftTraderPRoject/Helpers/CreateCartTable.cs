using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Helpers
{
    public class CreateCartTable
    { 
        public bool CreateTable()
        {
            try
            {
                var cn = DependencyService.Get<ISqlite>().GetConnection();
                cn.CreateTable<CartItem>();
                cn.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
