
const postPost = post => axios
    .post("/api/message", post)
    .then(() => location.href = "/photo/apiindex");

const initCreateForm = () => {
    const form = document.querySelector("#post-create-form");

    form.addEventListener("submit", e => {
        e.preventDefault();

        const post = getPostFromForm(form);
        postPost(post);
    });
};

const getPostFromForm = form => {
    const email = form.querySelector("#email").value;
    const text = form.querySelector("#text").value;

    return {
        id: 0,
        email,
        text,
    };
};