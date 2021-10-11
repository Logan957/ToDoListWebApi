using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListWebApi.Models.ToDos
{
    public class ToDoFilter
    {
        public IReadOnlyCollection<int> UserIds { get; set; }

        public bool? IsCompleted { get; set; }

        public ToDoFilter SetUserIds(IEnumerable<int> userIds)
        {
            UserIds = userIds?.Any() == true
                ? userIds as IReadOnlyCollection<int> ?? userIds.ToArray()
                : null;

            return this;
        }

        public ToDoFilter SetCompletedStatus(bool? isComplited)
        {
            IsCompleted = isComplited;

            return this;
        }
    }

}
