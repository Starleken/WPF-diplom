using Diplom.Resources.Model;
using Diplom.Resources.Scripts.HttpRequests.Repository;
using Diplom.Resources.Scripts.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diplom.Resources.Scripts
{
    public class NotificationViewController
    {
        public static NotificationViewController Instance { get; set; }

        private Border notificationBorder;
        private TextBlock notificationCount;

        public NotificationViewController(Border border, TextBlock text)
        {
            notificationBorder = border;
            notificationCount = text;
        }

        public void UpdateNotificationCount()
        {
            NotificationRepository repository = new NotificationRepository();
            StudentEntity student = new StudentRepository().GetStudentsByUser(AuthController.CurrentUser.id);
            string[] notifications = repository.GetAllByStudent(student.id);

            if (notifications.Length > 0)
            {
                notificationBorder.Visibility = System.Windows.Visibility.Visible;
                notificationCount.Text = (notifications.Length).ToString();
            }
            else
            {
                notificationBorder.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
