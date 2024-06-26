# Erp

## Descripción

ERP es un sistema de planificación de recursos empresariales diseñado para integrar y gestionar las operaciones centrales de una empresa. Este proyecto está enfocado en ofrecer una solución modular y escalable, utilizando las mejores prácticas en desarrollo de software.

## Estructura del Proyecto

El proyecto está organizado en los siguientes módulos:

- **Pavas.API**: Provee las API para interactuar con otros sistemas y aplicaciones.
- **Pavas.Abstractions**: Define interfaces y contratos utilizados en la aplicación.
- **Pavas.Application**: Contiene la lógica de negocio principal.
- **Pavas.Domain**: Incluye las entidades y reglas de dominio.
- **Pavas.Infrastructure**: Maneja la comunicación con la base de datos y otros servicios externos.

## Tecnologías Utilizadas

- **Lenguaje de programación**: C#
- **Contenedores**: Docker

## Configuración

Para configurar y ejecutar la aplicación localmente:

1. Clonar el repositorio:
    ```sh
    git clone https://github.com/juanpavasgarzon/Erp.git
    ```
2. Navegar al directorio del proyecto:
    ```sh
    cd Erp
    ```
3. Configurar y levantar los contenedores de Docker:
    ```sh
    docker-compose up
    ```

## Contribuciones

Las contribuciones son bienvenidas. Para contribuir, sigue estos pasos:

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-feature`).
3. Realiza los cambios necesarios y haz commits (`git commit -m 'Agrega nueva feature'`).
4. Sube tus cambios a tu fork (`git push origin feature/nueva-feature`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Contacto

Para preguntas o comentarios, contacta al autor del proyecto a través de su perfil de GitHub: [juanpavasgarzon](https://github.com/juanpavasgarzon).
