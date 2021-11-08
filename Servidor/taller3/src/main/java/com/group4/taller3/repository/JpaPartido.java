package com.group4.taller3.repository;

import com.group4.taller3.domain.entities.Partido;
import com.group4.taller3.domain.entities.PartidoPK;
import org.springframework.data.jpa.repository.JpaRepository;

public interface JpaPartido extends JpaRepository<Partido, PartidoPK> {
}
