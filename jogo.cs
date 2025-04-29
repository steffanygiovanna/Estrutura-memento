// Memento - Armazena o estado do texto no editor
class Memento {
    constructor(content) {
        this.content = content;
    }

    getContent() {
        return this.content;
    }
}

// Originator - O editor de texto que armazena e altera seu conteúdo
class TextEditor {
    constructor() {
        this.content = '';
    }

    setContent(content) {
        console.log(`Texto alterado para: ${content}`);
        this.content = content;
    }

    getContent() {
        return this.content;
    }

    // Cria e retorna um Memento com o estado atual
    save() {
        return new Memento(this.content);
    }

    // Restaura o estado a partir de um Memento
    restore(memento) {
        this.content = memento.getContent();
        console.log(`Texto restaurado para: ${this.content}`);
    }
}

// Caretaker - Armazena os Mementos, sem modificar seus conteúdos
class Caretaker {
    constructor() {
        this.mementos = [];
    }

    addMemento(memento) {
        this.mementos.push(memento);
    }

    getMemento(index) {
        return this.mementos[index];
    }
}

// Exemplo de uso:
const editor = new TextEditor();
const caretaker = new Caretaker();

// Editando o conteúdo do texto
editor.setContent("Primeira versão do texto");
caretaker.addMemento(editor.save());

editor.setContent("Segunda versão do texto");
caretaker.addMemento(editor.save());

editor.setContent("Terceira versão do texto");

// Restaurando para a versão anterior (segunda versão)
editor.restore(caretaker.getMemento(1));

// Restaurando para a primeira versão
editor.restore(caretaker.getMemento(0));
