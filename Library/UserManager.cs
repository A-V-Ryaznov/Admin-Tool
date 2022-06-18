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
    class UserManager
    {
        public static string UserFirstName { get; set; }
        public static string UserLastName { get; set; }
        public static string Username { get; set; }

        public static void WriteVisitLog()
        {
            History history = new History();

            history.Username = Username;
            DateTime thisDay = DateTime.Now;
            history.Datetime = thisDay;

            try
            {
                AdminToolEntities.GetContext().History.Add(history);
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
