﻿import { useEffect, useState } from "react"
import { Modal, ModalHeader, ModalBody, Form, FormGroup, Label, Input, ModalFooter, Button } from "reactstrap"

//se crea un modelo de inicio que indican todas las propiedades que va a contener
const modeloContacto = {
    idContacto : 0,
    nombre: "",
    correo: "",
    telefono: ""

}

const ModalContacto = ({ mostrarModal, setMostrarModal, guardarContacto, editar, setEditar, editarContacto }) => {

    const [contacto, setContacto] = useState(modeloContacto); //usestate que controla el estado de este modelo

    const actualizarDato = (e) => {

        console.log(e.target.name + " : " + e.target.value)
        setContacto(
            {
                ...contacto, // rescata todos los valores que tiene la variable contacto
                [e.target.name]: e.target.value
            }
        )        
    }

    const enviarDatos = () => {

        if (contacto.idContacto === 0) {
            guardarContacto(contacto)
        } else {
            editarContacto(contacto)
        }
    }

    useEffect(() => {
        if (editar != null) {
            setContacto(editar)
        } else {
            setContacto(modeloContacto)
        }

    },[editar])

    const cerrarModal = () => {
        setMostrarModal(!mostrarModal)
        setEditar(null)
    }
    return (
        <Modal isOpen={mostrarModal}>
            <ModalHeader>
                {contacto.idContacto==0 ? "Nuevo Contacto":"Editar contacto"}
               
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre</Label>
                        <Input name="nombre" onChange={(e) => actualizarDato(e)} value={contacto.nombre} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Correo</Label>
                        <Input name="correo" onChange={(e) => actualizarDato(e)} value={contacto.correo} />
                    </FormGroup>
                    <FormGroup>
                        <Label>Telefono</Label>
                        <Input name="telefono" onChange={(e) => actualizarDato(e)} value={contacto.telefono} />
                    </FormGroup>
                </Form>
            </ModalBody>

            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos} >Guardar</Button>
                <Button color="danger" size="sm" onClick={cerrarModal} >Cerrar</Button>
            </ModalFooter>
        </Modal>
    )
}
export default ModalContacto;