package com.group4.taller3.repository;

import com.group4.taller3.domain.entities.Participante;
import com.group4.taller3.domain.entities.Partido;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import javax.persistence.criteria.CriteriaBuilder;
import java.util.List;

public interface JpaParticipante extends JpaRepository<Participante,Integer> {

    @Query(value = "Select count(*) from partido where parcipante_1 = :par1",nativeQuery = true)
    Integer estadisticasBlanca(@Param("par1") Integer par1);

    @Query(value = "Select count(*) from partido where parcipante_2 = :par2",nativeQuery = true)
    Integer estadisticasNegra(@Param("par2") Integer par2);

    @Query(value = "SELECT * FROM  Participante where apodo LIKE CONCAT('%',:apodo,'%')" ,nativeQuery = true)
    List<Participante> filtrarPorApodo(@Param("apodo") String apodo);
}
