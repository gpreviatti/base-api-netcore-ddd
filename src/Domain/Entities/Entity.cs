using System;

namespace Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            if (Id == null)
            {
                Id = new Guid();
                CreatedAt = UpdatedAt = DateTime.Now;
            }
            else
            {
                UpdatedAt = DateTime.Now;
            }
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
