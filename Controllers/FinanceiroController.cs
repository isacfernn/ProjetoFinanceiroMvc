
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciamentoFinanceiro.Models;
using GerenciamentoFinanceiro.Data;

public class FinanceiroController : Controller
{
    private readonly AppDbContext _context;

    public FinanceiroController(AppDbContext context)
    {
        _context = context;
    }

    // GET: FINANCEIROS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Financas.ToListAsync());
    }

    // GET: FINANCEIROS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var financeiro = await _context.Financas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (financeiro == null)
        {
            return NotFound();
        }

        return View(financeiro);
    }

    // GET: FINANCEIROS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FINANCEIROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Descricao,Valor,DataOperacao,CategoriaId,Categoria,TransacaoId,Transacao")] Financeiro financeiro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(financeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(financeiro);
    }

    // GET: FINANCEIROS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var financeiro = await _context.Financas.FindAsync(id);
        if (financeiro == null)
        {
            return NotFound();
        }
        return View(financeiro);
    }

    // POST: FINANCEIROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Descricao,Valor,DataOperacao,CategoriaId,Categoria,TransacaoId,Transacao")] Financeiro financeiro)
    {
        if (id != financeiro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(financeiro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceiroExists(financeiro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(financeiro);
    }

    // GET: FINANCEIROS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var financeiro = await _context.Financas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (financeiro == null)
        {
            return NotFound();
        }

        return View(financeiro);
    }

    // POST: FINANCEIROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var financeiro = await _context.Financas.FindAsync(id);
        if (financeiro != null)
        {
            _context.Financas.Remove(financeiro);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FinanceiroExists(int? id)
    {
        return _context.Financas.Any(e => e.Id == id);
    }
}
