using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.DAL
{
    public sealed class StudentDataAccess
    {
        public static StudentDBEntity _dbContext;
        public static readonly object _lock = new object();

        private StudentDataAccess() { }
        
        public static StudentDBEntity GetInstance()
        {
            if (_dbContext == null)
            {
                lock (_lock)
                {
                    if (_dbContext == null)
                    {
                        _dbContext = new StudentDBEntity();
                        return _dbContext;
                    }
                }
            }
            return _dbContext;
        }
    }
}