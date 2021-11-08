package com.group4.taller3.controllers;


import com.group4.taller3.domain.entities.Mesa;
import com.group4.taller3.domain.entities.Participante;
import com.group4.taller3.domain.entities.Partido;
import com.group4.taller3.domain.entities.PartidoPK;
import com.group4.taller3.services.ServicioPartido;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@AllArgsConstructor
@RestController
@RequestMapping("/Partido")
public class ControllerPartido {

    private final ServicioPartido sp;

    @PostMapping("/Crear")
    public ResponseEntity<Partido> crearPartido(@RequestBody Partido partido){

        Object res = sp.crear(partido);

        HttpStatus status = HttpStatus.CREATED;
        try {
            if (res==null){
                throw new RuntimeException("No fue posible agregar el elemento");
            }
        }catch (RuntimeException e) {
            System.out.println(e.getMessage());
            status = HttpStatus.BAD_REQUEST;
        }
        return new ResponseEntity((Partido) res,status);

    }

    @PostMapping("/Buscar")
    public ResponseEntity<Partido> buscarPartido(@RequestBody PartidoPK id){
        Object res = sp.buscar(id);
        System.out.println(id.toString());
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
    public ResponseEntity<Partido> editarPartido(@RequestBody Partido partido){

        Object res = sp.actualizar(partido);
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

    @PostMapping("/Eliminar")
    public ResponseEntity<PartidoPK> eliminarPartido(@RequestBody PartidoPK id){

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
    public ResponseEntity<List<Partido>> listarParticipantes(){
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

}
