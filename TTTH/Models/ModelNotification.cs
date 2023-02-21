using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelNotification : ModelEntity
    {
        private string topic;
        private string content;
        private string userPosted;
        private DateTime created_date;

        public ModelNotification(int id, string topic, string content, string userPosted, DateTime created_date)
        {
            this.Id = id;
            this.topic = topic;
            this.content = content;
            this.userPosted = userPosted;
            this.created_date = created_date;
        }

        public string Topic { get => topic; set => topic = value; }
        public string Content { get => content; set => content = value; }
        public string UserPosted { get => userPosted; set => userPosted = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
        public string Created_dateDisplay
        {
            get
            {
                return created_date.ToString("dd/MM/yyyy");
            }
        }

        public string GetUserPostedName
        {
            get 
            {
                return userPosted;
            }
        }

        public override string? ToString()
        {
            return string.Format(
                "{0}, {1}",
                topic,content
                );
        }
    }
}
