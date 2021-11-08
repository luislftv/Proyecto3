package com.group4.taller3.controllers;


import com.group4.taller3.domain.entities.Mesa;
import com.group4.taller3.services.ServicioMesa;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@RestController
@RequestMapping("/Mesa")
public class ControllerMesa {


    private final ServicioMesa sm;

    @PostMapping("/Crear")
    public ResponseEntity<Mesa> crearMesa(@RequestBody Mesa mesa){
        System.out.println(mesa.toString());
        Object res = sm.crear(mesa);
        HttpStatus status = HttpStatus.CREATED;
        try {
            if (res==null){
                throw new RuntimeException("No fue posible agregar el elemento");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.BAD_REQUEST;
        }
        return new ResponseEntity(res,status);

    }

    @GetMapping("/Buscar/{id}")
    public ResponseEntity<Mesa> buscarMesa(@PathVariable("id") Integer id){

        Object res = sm.buscar(id);
        HttpStatus status = HttpStatus.FOUND;
        try {
            if (res==null){
                throw new RuntimeException("No fue posible agregar el elemento");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(res,status);

    }

    @PutMapping("/Editar")
    public ResponseEntity<Mesa> editarMesa(@RequestBody Mesa mesa){

        Object res = sm.actualizar(mesa);
        HttpStatus status = HttpStatus.OK;
        try {
            if (res==null){
                throw new RuntimeException("No fue posible editar el elemento");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(res,status);

    }

    @DeleteMapping("/Eliminar/{id}")
    public ResponseEntity<Integer> eliminarMesa(@PathVariable("id") Integer id){

        HttpStatus status = HttpStatus.OK;
        try {
            sm.eliminar(id);
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(id,status);

    }


    @GetMapping("/lista")
    public ResponseEntity<List<Mesa>> listarMesas(){
        List<Object> res = sm.listar();
        List<Mesa> tras = new ArrayList<Mesa>( (List<Mesa>) (Object) res);
        HttpStatus status = HttpStatus.FOUND;
        try {
            if (tras.isEmpty()){
                throw  new RuntimeException("No hay elementos");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(tras,status);
    }




}
