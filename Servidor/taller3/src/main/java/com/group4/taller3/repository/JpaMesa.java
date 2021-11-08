package com.group4.taller3.repository;

import com.group4.taller3.domain.entities.Mesa;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface JpaMesa extends JpaRepository<Mesa,Integer > {





}
