let nome = document.getElementById('UserName');
let email = document.getElementById('UserEmail');
let password = document.getElementById('UserPassword');
let confirmacao = document.getElementById('ConfirmPassword');
let form = document.querySelector('form');
let textform = document.getElementById('TextForm')
let textemail = document.getElementById('TextEmail')
let textnome = document.getElementById('TextNome')
let textconfirm = document.getElementById('TextConfirmPassword')
let textpassword = document.getElementById('TextPassword')

form.addEventListener('submit', (e) => {
    if (email.value == '' || password.value == '' || confirmacao.value == '' || nome.value == '') {
        textform.textContent = 'Preencha todos os campos!'
        e.preventDefault()
    } else if (Validar_Email(email.value) == true && Validar_Password(password.value) == true) {
        console.log('OK');
        textform.textContent = ''
        textconfirm.textContent = ''
        textpassword.textContent = ''
        textemail.textContent = ''
        textnome.textContent = ''

    } else {

        console.log('Requisição não atendida!')
        e.preventDefault()
    }

    
});

email.addEventListener('keyup', () => {
    if (Validar_Email(email.value) != true) {
        textemail.textContent = 'Digite um email correto!'
    } else {
        textemail.textContent = ''
    }
});

password.addEventListener('keyup', () => {
    if (Validar_Password(password.value) != true) {
        textpassword.textContent = 'Senha deve ter pelo menos 6 caracteres incluindo um caractere especial!'
    } else {
        textpassword.textContent = ''
    }
})

confirmacao.addEventListener('keyup', () => {
    if (confirmacao.value != password.value) {
        textconfirm.textContent = 'As senhas devem ser iguais!'
    } else {
        textconfirm.textContent = ''
    }
})

function Validar_Email(email) {
    let emailPattern =
        /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
    return emailPattern.test(email);

}

function Validar_Password(password) {
    let passwordPattern =
        /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;
    return passwordPattern.test(password);
}

