import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './components/Layout';
import Home from './Pages/Home';
import Pending from './Pages/Pending'
import Accepted from './Pages/Accepted'
import Declined from './Pages/Declined'
import ViewDetails from './Pages/ViewDetails'
import StatusCountContextComponent from './StatusCountContext'
import Add from './Pages/Add'

const App = () => {
    return (
        <StatusCountContextComponent>
            <Layout>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path='/Pending' element={<Pending />} />
                    <Route path='/Accepted' element={<Accepted />} />
                    <Route path='/Declined' element={<Declined />} />
                    <Route path='ViewDetails/:id' element={< ViewDetails />} />
                    <Route path='/AddPending' element={< Add />} />
                </Routes>
            </Layout>
        </StatusCountContextComponent>
    )
}

export default App;