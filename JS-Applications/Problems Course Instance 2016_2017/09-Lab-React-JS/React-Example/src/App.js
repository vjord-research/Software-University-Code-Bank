import React, {Component} from 'react';
// import logo from './logo.svg';
import './App.css';
import Header from './Header';
import Footer from './Footer';

class App extends Component {
    render() {
        return (
            <div className="App">
                <Header/>
                <p className="App-intro">
                    Hello from Nakov!
                </p>
                <Footer/>
            </div>
        );
    }
}

export default App;
