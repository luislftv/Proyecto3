package com.group4.taller3.services;


import com.group4.taller3.domain.entities.Participante;
import com.group4.taller3.domain.entities.Partido;
import com.group4.taller3.repository.JpaParticipante;
import lombok.AllArgsConstructor;
import org.hibernate.type.StringNVarcharType;
import org.springframework.stereotype.Repository;

import javax.persistence.criteria.CriteriaBuilder;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@AllArgsConstructor
@Repository
public class ServicioParticipante implements CRUD{

    private final JpaParticipante jp;

    @Override
    public Object crear(Object obj) {

        Participante creado = jp.save((Participante) obj);

        return (creado);
    }

    @Override
    public Object buscar(Object obj) {
        Integer i = (Integer) obj;
        Optional<Participante> buscado = jp.findById(i);
        return Optional.of(buscado.get());
    }

    @Override
    public Object actualizar(Object obj) {
        Integer id = ((Participante) obj).getId();
        System.out.println(id);
        Optional<Participante> buscado = jp.findById(id);
        if (buscado.isEmpty()){
            return null;
        }
        Participante actualizado = jp.save((Participante)  obj);
        return Optional.of(actualizado);
    }

    @Override
    public void eliminar(Object obj) {
        Integer i = (Integer) obj;
        Optional<Participante> m = jp.findById(i);
        jp.delete(m.get());
    }

    @Override
    public List<Object> listar() {
        List<Participante> l = jp.findAll();
        List<Object> r = new ArrayList<>(l);
        return r;
    }

    public Integer[] estadisticas(Integer id){

        Integer[] res = new Integer[2];

        res[0] = jp.estadisticasBlanca(id);
        res[1] = jp.estadisticasNegra(id);

        return res;
    }

    public List<Participante> filtrarParticipantePorNombre(String apodo){
        System.out.println(apodo);
        return jp.filtrarPorApodo(apodo.trim());
    }


}
