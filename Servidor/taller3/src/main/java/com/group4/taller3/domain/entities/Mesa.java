package com.group4.taller3.domain.entities;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;

import java.util.List;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity
@Data

@Table(name = "mesa")
public
class Mesa implements Serializable{


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_mesa", nullable = false)
    private Integer id_mesa;
    @Column(name = "localidad")
    private String localidad;
    @Column(name = "nombre_lugar")
    private String nombre_lugar;

    @OneToMany(mappedBy = "mesa", cascade = {CascadeType.PERSIST, CascadeType.MERGE} )
    @JsonProperty(access = JsonProperty.Access.WRITE_ONLY)
    private List<Partido> partidoList;

}
