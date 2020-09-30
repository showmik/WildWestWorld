//------------------------------------------------------------------------
//
//  Name:   EntityManager.cs
//
//  Desc:   Singleton class to handle the  management of Entities.
//
//------------------------------------------------------------------------

using System.Collections.Generic;

namespace WildeWest
{
    internal class EntityManager
    {
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

        // To facilitate quick lookup the entities are stored in a Dictionary, in which
        // pointers to entities are cross referenced by their ID number.
        private Dictionary<int, BaseGameEntity> entityMap;

        private EntityManager()
        {
            entityMap = new Dictionary<int, BaseGameEntity>();
        }

        //---------------------------- RegisterEntity ---------------------------
        // This method adds the entity in the Dictionary
        // with the ID number as key.
        //------------------------------------------------------------------------

        public void RegisterEntity(BaseGameEntity newEntity)
        {
            entityMap.Add(newEntity.ID, newEntity);
        }

        //---------------------------- GetEntityFromID ---------------------------
        // Returns entity with the ID given as a parameter.
        //------------------------------------------------------------------------
        public BaseGameEntity GetEntityFromID(int id)
        {
            return entityMap[id];
        }

        //---------------------------- GetEntityFromID ---------------------------
        // This method removes the entity from the Dictionary.
        //------------------------------------------------------------------------
        public void RemoveEntity(BaseGameEntity newEntity)
        {
            entityMap.Remove(newEntity.ID);
        }
    }
}