using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdminTool.Data;

namespace AdminTool.Library
{
    class DatabaseManager
    {
        /// <summary>
        /// Сохранение данных в бд
        /// </summary>
        /// <returns>Сохраняет данные в бд</returns>
        public static void DatabaseEntry()
        {
            try
            {
                AdminToolEntities.GetContext().SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }
    }
}
