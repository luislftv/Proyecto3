package com.group4.taller3.services;


import com.group4.taller3.domain.entities.Mesa;
import com.group4.taller3.repository.JpaMesa;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@AllArgsConstructor
@Data
@Service
public class ServicioMesa implements CRUD{

    private final JpaMesa jpaMesa;


    @Override
    public Object crear(Object obj) {

        Mesa creado = jpaMesa.save((Mesa) obj);

        return Optional.of(creado);
    }

    @Override
    public Object buscar(Object obj) {
        Optional<Mesa> buscado = jpaMesa.findById((Integer) obj);
        return Optional.of(buscado.get());
    }

    @Override
    public Object actualizar(Object obj) {
        Integer id = ((Mesa) obj).getId_mesa();
        System.out.println(id);
        Optional<Mesa> buscado = jpaMesa.findById(id);
        if (buscado.isEmpty()){
            return null;
        }
        Mesa actualizado = jpaMesa.save((Mesa) obj);
        return Optional.of(actualizado);
    }

    @Override
    public void eliminar(Object obj) {
        Integer i = (Integer) obj;
        Optional<Mesa> m = jpaMesa.findById(i);
        jpaMesa.delete(m.get());
    }

    @Override
    public List<Object> listar() {
        List<Mesa> l = jpaMesa.findAll();
        List<Object> r = new ArrayList<>(l);
        return r;
    }


}
