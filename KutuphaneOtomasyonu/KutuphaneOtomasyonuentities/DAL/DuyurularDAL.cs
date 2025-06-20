using Kütüphaneotomasyonu.entities.Model.context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.DAL
{
    public class DuyurularDAL : IDisposable
    {
        private readonly KutuphaneContext _context;

        public DuyurularDAL(KutuphaneContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Tüm duyuruları getir
        public List<Duyurular> GetAll()
        {
            return _context.Duyurular.AsNoTracking().ToList();
        }

        public async Task<List<Duyurular>> GetAllAsync()
        {
            return await _context.Duyurular.AsNoTracking().ToListAsync();
        }

        // ID ile getir
        public Duyurular GetById(int id)
        {
            return _context.Duyurular.AsNoTracking().FirstOrDefault(d => d.Id == id);
        }

        // Ekle veya güncelle
        public void InsertOrUpdate(Duyurular duyuru)
        {
            if (duyuru == null) throw new ArgumentNullException(nameof(duyuru));

            if (duyuru.Id == 0)
            {
                _context.Duyurular.Add(duyuru);
            }
            else
            {
                _context.Entry(duyuru).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        // Silme
        public void Delete(int id)
        {
            var duyuru = _context.Duyurular.Find(id);
            if (duyuru != null)
            {
                _context.Duyurular.Remove(duyuru);
                _context.SaveChanges();
            }
        }

        // Toplu silme
        public void DeleteMultiple(List<int> ids)
        {
            var duyurular = _context.Duyurular.Where(d => ids.Contains(d.Id));
            _context.Duyurular.RemoveRange(duyurular);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}