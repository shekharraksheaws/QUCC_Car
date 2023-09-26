using System;
using System.Collections.Generic;

namespace DataLibrary.Model;

public partial class TblCar
{
    public Guid Id { get; set; }

    public string RegNo { get; set; } = null!;

    public string? Brand { get; set; }

    public DateTime? RegYear { get; set; }

    public string SourceType { get; set; } = null!;

    public string ScCode { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Colour { get; set; } = null!;

    public DateTime ModelYear { get; set; }

    public int Mileage { get; set; }

    public string EngineNo { get; set; } = null!;

    public string ChassisNo { get; set; } = null!;

    public string? FuelType { get; set; }
}
