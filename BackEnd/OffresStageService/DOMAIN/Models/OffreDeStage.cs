using DOMAIN.Models;
using System;
using System.Collections.Generic;

public class OffreDeStage
{
    public Guid Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public string Domaine { get; set; }
    public DateTime DatePublication { get; set; }
    public DateTime DateExpiration { get; set; }

    // Navigation properties
    public ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();
    public ICollection<Stage> Stages { get; set; } = new List<Stage>();
}
