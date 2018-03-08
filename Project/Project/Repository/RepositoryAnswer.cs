﻿using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryAnswer<Answer> : IRepository<Answer>
        where Answer : class
    {
        protected DataContext Context = null;

        public RepositoryAnswer()
        {
            this.Context = new DataContext();

        }
        public RepositoryAnswer(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Answer> DbSet
        {
            get
            {
                return Context.Set<Answer>();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
        public int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public IQueryable<Answer> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Answer, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Answer Create(Answer Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Answer, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Answer t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Answer> Filter(Expression<Func<Answer, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Answer>();
        }



        public Answer Find(Expression<Func<Answer, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Answer t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}