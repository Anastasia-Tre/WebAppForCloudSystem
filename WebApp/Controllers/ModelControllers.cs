using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model.Models;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : BaseController<Album>
{
    public AlbumController(IBaseService<Album> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class ArtistController : BaseController<Artist>
{
    public ArtistController(IBaseService<Artist> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class CustomerController : BaseController<Customer>
{
    public CustomerController(IBaseService<Customer> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : BaseController<Employee>
{
    public EmployeeController(IBaseService<Employee> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class GenreController : BaseController<Genre>
{
    public GenreController(IBaseService<Genre> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : BaseController<Invoice>
{
    public InvoiceController(IBaseService<Invoice> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class InvoiceLineController : BaseController<InvoiceLine>
{
    public InvoiceLineController(IBaseService<InvoiceLine> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class MediaTypeController : BaseController<MediaType>
{
    public MediaTypeController(IBaseService<MediaType> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class PlaylistController : BaseController<Playlist>
{
    public PlaylistController(IBaseService<Playlist> service) : base(service)
    {
    }
}

[ApiController]
[Route("api/[controller]")]
public class TrackController : BaseController<Track>
{
    public TrackController(IBaseService<Track> service) : base(service)
    {
    }
}