﻿using DotnetWebApiDemo.Domain.Interfaces;
using DotnetWebApiDemo.Infra.Data.EF.Context;
using System;
using System.Threading.Tasks;

namespace DotnetWebApiDemo.Infra.Data.EF.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;
        private bool _disposed;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
