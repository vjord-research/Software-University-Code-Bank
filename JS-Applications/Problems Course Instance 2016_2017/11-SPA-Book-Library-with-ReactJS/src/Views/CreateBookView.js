import React, {Component} from 'react';

export default class CreateBookView extends Component {
    render() {
        return (
            <form className="create-book-form" onSubmit={this.submitForm.bind(this)}>
                <h1>Create Book</h1>
                <label>
                    <div>Title:</div>
                    <input type="text" required
                           ref={e => this.titleField = e}/>
                </label>
                <label>
                    <div>Author:</div>
                    <input type="text" required
                           ref={e => this.authorField = e}/>
                </label>
                <label>
                    <div>Description:</div>
                    <textarea type="text" rows="10"
                              ref={e => this.descriptionField = e}>
                    </textarea>
                </label>
                <div>
                    <input type="submit" value="Create"/>
                </div>
            </form>
        );
    }

    submitForm(event) {
        event.preventDefault();

        this.props.onsubmit(
            this.titleField.value,
            this.authorField.value,
            this.descriptionField.value);
    }
}