package com.group4.taller3.domain.entities;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Data;

import java.io.Serializable;

import java.util.Date;

import java.util.List;

import javax.persistence.*;

@Data
@Entity
@NamedQueries({ @NamedQuery(name = "Participante.findAll", query = "select o from Participante o") })
@Table(name = "participante")
public class Participante implements Serializable {
    private static final long serialVersionUID = 2724908626026484325L;

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;
    @Column(name = "apodo", nullable = false, unique = true)
    private String apodo;
    @Temporal(TemporalType.DATE)
    @Column(name = "fecha_caducidad", nullable = false)
    private Date fecha_caducidad;
    @Temporal(TemporalType.DATE)
    @Column(name = "fecha_inscripcion", nullable = false)
    private Date fecha_inscripcion;

    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @OneToMany(mappedBy = "participante", cascade = {CascadeType.PERSIST, CascadeType.MERGE})
    private List<Partido> partidoList;
    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @OneToMany(mappedBy = "participante1", cascade = {CascadeType.PERSIST, CascadeType.MERGE})
    private List<Partido> partidoList1;
}