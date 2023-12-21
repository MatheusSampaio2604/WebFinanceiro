import TogleDash from './TogleDash';
import "../../componentsGTA/stylesedit.css";
import { useState } from 'react';

interface Props {
    dashMode: string;
    handleDateMode: any;
    dateMode: string;
    handleDateBeginChange: any;
    handleDateEndChange: any;
    handleModeChanged: any;
    handleConsolidationChanged: any;
    toggleMode: string;
    handleClickButton: any;
}

function DashOptions({ handleDateBeginChange, handleClickButton,handleDateEndChange, handleModeChanged, dashMode, toggleMode, handleConsolidationChanged, dateMode, handleDateMode }: Props) {
    const [isVisible, setIsVisible] = useState(false);
    

    return (
        <>
                <div >
                    <div className="flex ml-2 gap-4">
                        <TogleDash handleClickButton={handleClickButton} handleDateBeginChange={handleDateBeginChange} handleDateEndChange={handleDateEndChange} handleModeChanged={handleModeChanged} dashMode={dashMode} handleDateMode={handleDateMode} dateMode={dateMode} />
                    </div>
                </div>

           
        </>
    );
}

export default DashOptions;