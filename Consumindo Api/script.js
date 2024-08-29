function PegarValor(){
    let valor = document.querySelector(".nome").value;
    BuscarDados(valor);
}
async function BuscarDados(valor){
    const jsonPaciente = await fetch(`http://localhost:5237/api/Paciente`).then(Response => Response.json());
    const jsonMedico = await fetch(`http://localhost:5237/api/Medico`).then(Response => Response.json());
    const jsonMedicamento = await fetch(`http://localhost:5237/api/Medicamento`).then(Response => Response.json());
    const jsonEspecialidade = await fetch(`http://localhost:5237/api/Especialidade`).then(Response => Response.json());
    const jsonConsulta = await fetch(`http://localhost:5237/api/Consulta`).then(Response => Response.json());
    Dados(jsonPaciente,jsonMedico,jsonMedicamento,jsonEspecialidade,jsonConsulta,valor);
}
function Dados(jsonPaciente,jsonMedico,jsonMedicamento,jsonEspecialidade,jsonConsulta,valor){
    let paciente = jsonPaciente.find(p => p.nome.toLowerCase() === valor.toLowerCase());
    if (!paciente){
        alert("Paciente inexistente");
    }
    let consulta = jsonConsulta.find(c => c.pacienteId === paciente.pacienteId);
    let medico = jsonMedico.find(m => m.medicosId === consulta.medicoId);
    let medicamento = jsonMedicamento.find(m => m.consultaId === consulta.consultaId);
    let especialidade = jsonEspecialidade.find(e => e.especialidadeId === consulta.consultaId);
    Troca(consulta,medico,medicamento,especialidade);
    
}
function Troca(consulta,medico,medicamento,especialidade){
    document.querySelector(".medicotroca").value = medico.nome; 
    document.querySelector("#especialidade").value = especialidade.nome; 
    document.querySelector("#procedimento").value = consulta.procedimento; 
    document.querySelector("#data").value = consulta.dataConsulta;
    document.querySelector("#medicamento").value = medicamento.nomeMedicamento;
}
