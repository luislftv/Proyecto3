package com.group4.taller3.domain.entities;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;

@AllArgsConstructor
@NoArgsConstructor
@Data
@Builder
@Embeddable
public class PartidoPK implements Serializable {

    private static final long serialVersionUID = 1L;

    @Column(name = "parcipante_1")
    private int participante;
    @Column(name = "parcipante_2")
    private int participante1;
    @Column(name = "mesa_id")
    private int mesa;

}

