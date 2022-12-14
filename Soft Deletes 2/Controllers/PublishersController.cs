namespace SoftDeletes.Controllers;
public class PublishersController : Controller
{
    private readonly LibraryContext _context;

    public PublishersController(LibraryContext context)
    {
        _context = context;
    }

    // GET: Publishers
    public async Task<IActionResult> Index()
    {
            return View(await _context.Publisher.ToListAsync());
    }

    // GET: Publishers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Publisher == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher
            .FirstOrDefaultAsync(m => m.ID == id);
        if (publisher == null)
        {
            return NotFound();
        }

        return View(publisher);
    }

    // GET: Publishers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Publishers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Name")] Publisher publisher)
    {
        if (ModelState.IsValid)
        {
            _context.Add(publisher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(publisher);
    }

    // GET: Publishers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Publisher == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher.FindAsync(id);
        if (publisher == null)
        {
            return NotFound();
        }
        return View(publisher);
    }

    // POST: Publishers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Publisher publisher)
    {
        if (id != publisher.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(publisher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.ID))
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
        return View(publisher);
    }

    // GET: Publishers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Publisher == null)
        {
            return NotFound();
        }

        var publisher = await _context.Publisher
            .FirstOrDefaultAsync(m => m.ID == id);
        if (publisher == null)
        {
            return NotFound();
        }

        return View(publisher);
    }

    // POST: Publishers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Publisher == null)
        {
            return Problem("Entity set 'LibraryContext.Publisher'  is null.");
        }
        var publisher = await _context.Publisher.FindAsync(id);
        if (publisher != null)
        {
            _context.Publisher.Remove(publisher);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PublisherExists(int id)
    {
        return _context.Publisher.Any(e => e.ID == id);
    }
}