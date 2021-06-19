using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
