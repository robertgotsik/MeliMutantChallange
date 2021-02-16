# MeliMutantChallange

Para ejecutar la API se debe apuntar a la direccion: http://3.14.114.206/MutantDetector/api/adns/

Utilizando el Postman, por ejemplo, es posible ejecutar dos controllers:
1) Detector de mutantes (nivel 2): en caso de querer detectar si el adn es humano o mutante, agregar la extension "/mutant" a la URL original. La peticion debe ser un POST con un body similar al siguiente:
  {"dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]}
2) Servicio de estadisticas (nivel 3): en caso de querer conocer la cantidad de humanos/mutantes y el ratio, agregar la extension "/stats" a la URL original. La peticion debe ser un GET.
