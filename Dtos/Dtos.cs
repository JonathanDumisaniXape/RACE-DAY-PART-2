using System.ComponentModel.DataAnnotations;

namespace RaceDay.Api.Dtos;

public class RegisterRequest
{
    [Required, StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    [Required, RegularExpression("^(Organiser|Participant)$", ErrorMessage = "Role must be either 'Organiser' or 'Participant'.")]
    public string Role { get; set; } = string.Empty;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }
}

public class LoginRequest
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}

public record LoginResponse(string Token, string Role, int UserId);

// ---------------------------------------------------------------- Users
public record UserDto(int UserId, string FullName, string Email, string Role, string? PhoneNumber, DateTime CreatedAt);

public record PublicUserDto(int UserId, string FullName, string Role);

public class UpdateProfileRequest
{
    [Required, StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }
}

// ---------------------------------------------------------------- Venues
public record VenueDto(int VenueId, string Name, string? AddressLine, string City, string? Province, decimal? Latitude, decimal? Longitude);

public class VenueRequest
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string? AddressLine { get; set; }

    [Required, StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Province { get; set; }

    [Range(-90, 90)]
    public decimal? Latitude { get; set; }

    [Range(-180, 180)]
    public decimal? Longitude { get; set; }
}

// ---------------------------------------------------------------- Events
public class EventRequest
{
    [Required, StringLength(150)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public DateOnly? EventDate { get; set; }

    [Required, RegularExpression("^(Running|Walking|Cycling)$", ErrorMessage = "EventType must be Running, Walking or Cycling.")]
    public string EventType { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "A valid VenueId is required.")]
    public int VenueId { get; set; }
}

public record EventSummaryDto(
    int EventId, string Title, string? Description, DateOnly EventDate, string EventType,
    int OrganiserId, int VenueId, string VenueName, string City, string? Province);

public record EventDetailDto(
    int EventId, string Title, string? Description, DateOnly EventDate, string EventType,
    int OrganiserId, VenueDto Venue, IReadOnlyList<CategoryDto> Categories);

// ---------------------------------------------------------------- Categories
public class CategoryRequest
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999.99)]
    public decimal DistanceKm { get; set; }

    [Range(0, 999999.99)]
    public decimal EntryFee { get; set; }

    [Range(1, 1000000)]
    public int MaxParticipants { get; set; } = 100;
}

public record CategoryDto(int CategoryId, int EventId, string Name, decimal DistanceKm, decimal EntryFee, int MaxParticipants);

// ---------------------------------------------------------------- Enrolments
public record EnrolResponse(int EnrolmentId, string? BibNumber);

public record EnrolmentDto(
    int EnrolmentId, int ParticipantId, string ParticipantName, int CategoryId, string CategoryName,
    int EventId, string EventTitle, DateOnly EventDate, string? BibNumber, string Status, DateTime EnrolmentDate);

// ---------------------------------------------------------------- Results
public class ResultRequest
{
    public TimeSpan? FinishTime { get; set; }

    [Range(1, int.MaxValue)]
    public int? Position { get; set; }

    [Required, RegularExpression("^(Finished|DNF|DNS)$", ErrorMessage = "Status must be Finished, DNF or DNS.")]
    public string Status { get; set; } = "Finished";
}

public record ResultDto(
    int ResultId, int EnrolmentId, int ParticipantId, string ParticipantName, string? BibNumber,
    int EventId, string EventTitle, string CategoryName, TimeSpan? FinishTime, int? Position, string Status);
