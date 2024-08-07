import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react"
import { Container, Row, Col, Card, CardHeader, CardBody, Button } from "reactstrap"
import ModalContacto from "./Componentes/ModalContacto"
import TablaContacto from "./Componentes/TablaContacto"

const App = () => {

    const [contactos, setContactos] = useState([])//[] indican array de datos vacio que indica como va a iniciar el estado al inicio
    //se crea el metodo que lista los contactos llamando al api

    const [mostrarModal, setMostrarModal] = useState(false);
    const [editar, setEditar] = useState(null);

    const mostrarContactos = async () => {
        const response = await fetch("api/contacto/Lista");
        if (response.ok) {
            const data = await response.json();
            setContactos(data);
        }
        else {
            console.log("error en la lista")
        }
    }

    useEffect(() => {
        mostrarContactos()
    }, [])//useEffect llama este metodo de mostrarContactos al Iniciar la Aplicacion 

    const guardarContacto = async (contacto) => {
        const response = await fetch("api/contacto/Guardar", {
            method: 'POST',
            headers: {
                'Content-Type':'application/json;charset=utf-8'
            },
            body: JSON.stringify(contacto)
        })
        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarContactos();
        }
    }

    const editarContacto = async (contacto) => {
        const response = await fetch("api/contacto/Editar", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(contacto)
        })
        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarContactos();
        }
    }

    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de contactos</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success" onClick={() => setMostrarModal(!mostrarModal)}>Nuevo Contacto</Button>
                            <hr></hr>
                            <TablaContacto data={contactos}
                                setEditar={setEditar}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}
                            />
                           
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ModalContacto
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarContacto={guardarContacto}

                editar={editar}
                setEditar={setEditar}
                editarContacto={editarContacto}
            />
        </Container>
    )

}
export default App;