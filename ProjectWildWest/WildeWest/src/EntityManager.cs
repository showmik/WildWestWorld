using System.Collections.Generic;

namespace WildeWest
{
    internal class EntityManager
    {
        private Dictionary<int, BaseGameEntity> entityMap;

        private static EntityManager instance;

        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityManager();
                }
                return instance;
            }
        }

        private EntityManager()
        {
            entityMap = new Dictionary<int, BaseGameEntity>();
        }

        public void RegisterEntity(BaseGameEntity newEntity)
        {
            entityMap.Add(newEntity.ID, newEntity);
        }

        public BaseGameEntity GetEntityFromID(int id)
        {
            return entityMap[id];
        }

        public void RemoveEntity(BaseGameEntity newEntity)
        {
            entityMap.Remove(newEntity.ID);
        }
    }
}