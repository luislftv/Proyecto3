package com.group4.taller3.controllers;

import com.group4.taller3.domain.entities.Mesa;
import com.group4.taller3.domain.entities.Participante;
import com.group4.taller3.domain.entities.Partido;
import com.group4.taller3.services.ServicioParticipante;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@RestController
@RequestMapping("/Participante")
public class ControllerParticipante {

    private final ServicioParticipante sp;

    @PostMapping("/Crear")
    public ResponseEntity<Participante> crearParticipante(@RequestBody Participante participante){

        Object res = sp.crear(participante);
        HttpStatus status = HttpStatus.CREATED;
        try {
            if (res==null){
                throw new RuntimeException("No fue posible agregar el elemento");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.BAD_REQUEST;
        }
        return new ResponseEntity((Participante) res,status);

    }

    @GetMapping("/Buscar/{id}")
    public ResponseEntity<Participante> buscarParticipante(@PathVariable("id") Integer id){

        Object res = sp.buscar(id);
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
    public ResponseEntity<Participante> editarParticipante(@RequestBody Participante participante){

        Object res = sp.actualizar(participante);
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
    public ResponseEntity<String> eliminarParticipante(@PathVariable("id") Integer id){

        HttpStatus status = HttpStatus.OK;
        try {
            sp.eliminar(id);
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(id,status);

    }


    @GetMapping("/Lista")
    public ResponseEntity<List<Mesa>> listarParticipantes(){
        List<Object> res = sp.listar();
        List<Participante> tras = new ArrayList<Participante>( (List<Participante>) (Object) res);
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

    @GetMapping("/Lista/estadisticas/{id}")
    public ResponseEntity<Integer[]> listarEstadisticasParticipante(@PathVariable("id")Integer i){
        Integer[] tras = sp.estadisticas(i);
        HttpStatus status = HttpStatus.FOUND;
        try {
            if (tras==null){
                throw  new RuntimeException("No hay elementos");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(tras,status);
    }


    @GetMapping("/Lista/Filtrar/{apodo}")
    public ResponseEntity<List<Participante>> listarFiltrados(@PathVariable("apodo")String i){
        List<Participante> res = sp.filtrarParticipantePorNombre(i);
        HttpStatus status = HttpStatus.FOUND;
        try {
            if (res.isEmpty()){
                throw  new RuntimeException("No hay elementos");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.NOT_FOUND;
        }
        return new ResponseEntity(res,status);
    }

}
