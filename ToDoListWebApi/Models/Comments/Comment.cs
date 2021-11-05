using System.Text.Json.Serialization;
using ToDoListWebApi.DataBase.Models.Users;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }

        /// <summary>
        /// Id пользователя - автора комментария
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Id ToDo на котором был оставлен комментарий
        /// </summary>
        public int? ToDoId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Пользователь - автор комментария
        /// </summary>
        public User User { get; set; }

        [JsonIgnore]
        public ToDo ToDo { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }
    }
}
