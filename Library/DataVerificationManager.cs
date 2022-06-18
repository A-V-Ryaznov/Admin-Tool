using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminTool.Library
{
    class DataVerificationManager
    {
        /// <summary>
        /// Проверка на корректность введенного количества игроков в сети
        /// </summary>
        /// <param name="textbox">поле в котором осуществляется проверка</param>
        /// <returns bool>Являеются ли данные корректными</returns>
        public static bool CheckValueOnlinePlayer(string textbox)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textbox))
            {
                error.AppendLine("Вы не задали значение");
            }

            if (textbox != null)
            {
                foreach (var number in textbox)
                {
                    if (!char.IsDigit(number))
                    {
                        error.AppendLine("Количество игроков заполняется только в числовом формате");
                        break;
                    }
                }

                if (Convert.ToInt32(textbox) > Library.SettingManager.MaximumCountPlayers || Convert.ToInt32(textbox) < 0)
                {
                    error.AppendLine($"Максимальное количество игроков на сервере = {Library.SettingManager.MaximumCountPlayers}. Минимальное = 0");
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка на корректность данных игрока, который введен в черный список
        /// </summary>
        /// <param name="playerName">имя игрока</param>
        /// <param name="Steam64">игрока Steam64</param>
        /// <param name="reasonForBlocking">Причина блокировки игрока</param>
        /// <returns bool>Является ли данные корретными</returns>
        public static bool CheckValueTransferToDatabaseBlackList(string playerName, string Steam64, string reasonForBlocking)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                error.AppendLine("Укажите имя пользователя");
            }
            if (string.IsNullOrWhiteSpace(Steam64))
            {
                error.AppendLine("Введите Steam64");
            }

            if (string.IsNullOrWhiteSpace(reasonForBlocking))
            {
                error.AppendLine("Укажите причину блокировки");
            }
            if (reasonForBlocking != null)
            {
                if (reasonForBlocking.Length > 40)
                {
                    error.AppendLine("Причина блокировки может быть не больше 40 символов");
                }
            }

            if (Steam64 != null)
            {
                if (Steam64.Length > 17 || Steam64.Length < 17)
                {
                    error.AppendLine("Steam64 должен быть равен 17 символам");
                }
                //проверяем на то, что Steam64 содержит числа
                foreach (var steam64 in Steam64)
                {
                    if (!char.IsDigit(steam64))
                    {
                        error.AppendLine("Steam64 должен содержать в себе только числа");
                        break;
                    }
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Проверка на корректность данных игрока, который введен в модераторский список
        /// </summary>
        /// <param name="firstName">имя модератора</param>
        /// <param name="lastName">фамилия модератора</param>
        /// <param name="Steam64">Steam64 модератора</param>
        /// <returns bool>Является ли данные корретными</returns>
        public static bool CheckValueTransferToDatabaseModeratorList(string firstName, string lastName, string Steam64)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                error.AppendLine("Укажите имя модератора");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                error.AppendLine("Укажите фамилию модератора");
            }
            if (Steam64 != null)
            {
                if (Steam64.Length > 17 || Steam64.Length < 17)
                {
                    error.AppendLine("Steam64 должен быть равен 17 символам");
                }
                //проверяем на то, что Steam64 содержит числа
                foreach (var steam64 in Steam64)
                {
                    if (!char.IsDigit(steam64))
                    {
                        error.AppendLine("Steam64 должен содержать в себе только числа");
                        break;
                    }
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Проверка на корректность данных игрока, который введен в белый список
        /// </summary>
        /// <param name="playerNickname">имя игрока</param>
        /// <param name="Steam64">Steam64 игрока</param>
        /// <returns bool>Является ли данные корретными</returns>
        public static bool CheckValueTransferToDatabaseWhiteList(string playerNickname, string Steam64)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(playerNickname))
            {
                error.AppendLine("Укажите имя пользователя");
            }
            if (Steam64 == null)
            {
                error.AppendLine("Введите Steam64");
            }
            if (Steam64 != null)
            {
                if (Steam64.Length > 17 || Steam64.Length < 17)
                {
                    error.AppendLine("Steam64 должен быть равен 17 символам");
                }
                //проверяем на то, что Steam64 содержит числа
                foreach (var steam64 in Steam64)
                {
                    if (!char.IsDigit(steam64))
                    {
                        error.AppendLine("Steam64 должен содержать в себе только числа");
                        break;
                    }
                }
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Проверка на корректность данных для настройки максимального количества игроков
        /// </summary>
        /// <param name="count">значение, которое принимается за число</param>
        /// <returns bool>Является ли данные корретными</returns>
        public static bool CheckValueMaximumServerPlayer(string count)
        {
            bool isCount = true;

            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(count))
            {
                error.AppendLine("Задайте значение максимального кол-ва игроков на сервере");
            }

            if (count != null)
            {
                //проверяем на то, что поле содержит числа
                foreach (var number in count)
                {
                    if (!char.IsDigit(number))
                    {
                        error.AppendLine("Максимальное кол-во игроков может быть только числом");
                        isCount = false;
                        break;
                    }
                }
            }
            if(isCount == true)
            {
                if (Convert.ToInt32(count) < 0)
                {
                    error.AppendLine("Максимальное кол-во игроков не может быть меньше 0");
                }
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Были найдены ошибки записи", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
