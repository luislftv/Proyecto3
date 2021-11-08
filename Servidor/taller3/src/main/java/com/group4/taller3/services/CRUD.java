package com.group4.taller3.services;

import java.util.List;
import java.util.Optional;

public interface CRUD {

    Object crear (Object obj);
    Object buscar (Object obj);
    Object actualizar (Object obj);
    void eliminar (Object obj);
    List<Object> listar ();
}
