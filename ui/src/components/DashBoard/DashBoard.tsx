import {  Button } from '@mui/material';

import Breadcrumb from '../../components/Breadcrumb';
import DefaultLayout from '../../layout/DefaultLayout';



function Analisy() {

 

    return (
        <DefaultLayout>
            <Breadcrumb pageName="Análises" />
            <div style={{ display: "flex", justifyContent: "flex-end" }}>
                <Button variant="contained" size="large" color="success" >
                    Adicionar
                </Button>

                <div className="mx-2"></div>
                <Button variant="contained" size="small" color="warning" >
                    Editar
                </Button>

            </div>
           

        
           

        </DefaultLayout>
    );
}

export default Analisy;