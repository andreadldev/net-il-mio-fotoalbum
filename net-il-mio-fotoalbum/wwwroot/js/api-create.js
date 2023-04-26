
const postMessage = message => axios
    .post("/api/message", message)
    .then(() => location.href = "/photo/apiindex");

const initCreateForm = () => {
    const form = document.querySelector("#message-create-form");

    form.addEventListener("submit", e => {
        e.preventDefault();

        const message = getMessageFromForm(form);
        postMessage(message);
    });
};

const getMessageFromForm = form => {
    const email = form.querySelector("#email").value;
    const text = form.querySelector("#text").value;

    return {
        id: 0,
        email,
        text,
    };
};