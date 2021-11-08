package com.group4.taller3.services;

import com.group4.taller3.domain.entities.Participante;
import com.group4.taller3.domain.entities.Partido;
import com.group4.taller3.domain.entities.PartidoPK;
import com.group4.taller3.repository.JpaPartido;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class ServicioPartido implements CRUD {

    private final JpaPartido jp;

    @Override
    public Object crear(Object obj) {

        Partido creado = jp.save((Partido) obj);
        return (creado);
    }

    @Override
    public Object buscar(Object obj) {
        PartidoPK i = (PartidoPK) obj;
        Optional<Partido> buscado = jp.findById(i);
        return Optional.of(buscado.get());
    }

    @Override
    public Object actualizar(Object obj) {
        PartidoPK i = ((Partido) obj).getId();
        Optional<Partido> buscado = jp.findById(i);
        if (buscado.isEmpty()){
            return null;
        }
        Partido actualizado = jp.save((Partido)  obj);
        return Optional.of(actualizado);
    }

    @Override
    public void eliminar(Object obj) {
        PartidoPK i = (PartidoPK) obj;
        Optional<Partido> m = jp.findById(i);
        jp.delete(m.get());
    }

    @Override
    public List<Object> listar() {
        List<Partido> l = jp.findAll();
        List<Object> r = new ArrayList<>(l);
        return r;
    }

    public List<Partido> listarPartidosParticipante(Integer key){
        
        List<Partido> t = jp.findAll();
        List<Partido> n = new ArrayList<>();
        for (Partido p : t) {
            PartidoPK k = p.getId();
            if (k.getParticipante1()==key ||k.getParticipante()==key){
                n.add(p);
            }
        }
        return n;
    }
    
    
}
