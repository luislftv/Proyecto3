package com.group4.taller3.domain.entities;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;

import java.sql.Timestamp;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity
@Data
@Table(name = "partido")
public class Partido implements Serializable {

    @EmbeddedId
    private PartidoPK id;
    @Column(name = "fecha_programada", nullable = false)
    private Timestamp fecha_programada;
    @Column(name = "ganador", nullable = false)
    private int ganador;
    @Column(name = "hora_fin", nullable = false)
    private Timestamp hora_fin;
    @Column(name = "hora_inicio", nullable = false)
    private Timestamp hora_inicio;
    @Column(name = "ronda", nullable = false)
    private int ronda;
    @Column(name = "torneo", nullable = false)
    private String torneo;


    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @ManyToOne
    @JoinColumn(name = "parcipante_2", referencedColumnName = "id", updatable = false,insertable = false)
    private Participante participante;

    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @ManyToOne
    @JoinColumn(name = "parcipante_1", referencedColumnName = "id", updatable = false,insertable = false)
    private Participante participante1;

    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    @ManyToOne(optional=false)
    @JoinColumn(name = "mesa_id", referencedColumnName = "id_mesa",updatable = false,insertable = false)
    private Mesa mesa;
}