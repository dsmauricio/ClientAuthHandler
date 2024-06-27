# ClientAuthHandler

This is a demonstration of how to use a custom HttpClient delegating handler to authenticate your api requests using a bearer token.

Also it demonstrate how to implement a decorator pattern to cache the token and refresh it before it expires.

Uses: 
- .Net 8
- File scoped namespaces
- Typed HttpClients for Authentication service and for the API service
- Scrutor to register cache decorator
- MemoryCache to store the token in memory
- Logger to identify the order in which the authentication service runs before and after the decorator

Questions to : mauricio@atanache.com / dsmauricio@yahoo.com

## Espanol

Este es un ejemplo de como usar un delegating handler personalizado para autenticar tus peticiones a una API usando un token de tipo bearer.

Tambien se muestra como implementar un patron decorador para almacenar el token en memoria cache y refrescarlo antes de que expire.

Usa:
- .Net 8
- Namespaces a nivel de archivo
- Typed HttpClients para el servicio de autenticacion y para el servicio de la API
- Scrutor para registrar el decorador de cache
- MemoryCache para almacenar el token en memoria
- Logger para identificar el orden en que se ejecutan el servicio de autenticacion antes y despues del decorador

Preguntas a : mauricio@atanache.com / dsmauricio@yahoo.com