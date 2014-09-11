
//Ensemble de fonction qui permet de faire les calcule des assessements
(function ($) {

    //Calcule les points de PPM
    calculePPM = function (value) {
        if (value <= 500){
            return 20; //Return 20 Si le PPM est inférieur à 500
        }
        else if (value >= 10000) {
            return 0;// return 0 Si le PPM est Suppérieur à 10000
        }
        else{
            return parseInt(20 - value / 1000 * 2); //Calcule : -2pts pour 1000PPM
        }
    };
    //Calcule les pour le nombre de probleme qualité
    qualityProblemes = function (value) {
        if ((20 - 5 * value) <= 0) {
            return 0;
        }
        else {
            return (20 - 5 * value);
        }
    };
    //Calcule le nombre de point par return client
    retourClient = function (value) {
        return value * -15;
    };
    //Calcule des points de bonus PPM
    BonusPPM = function (valuePPM, valueCustumer) {
        //Si J'ai un retour client pas de bonus
        if(valueCustumer > 0){
            return 0;
        }
        //Si le nombre de PPm est Supérieur à 500 pas de bonus
        else if (valuePPM > 500) {
            return 0;
        }
        //Sinon 1 pts pour 100ppm
        else {
            return parseInt((500 - valuePPM) / 100 * 2);
        }
        
    };
    //Calcule du taux de service
    tauxService = function (value) {
        var temp
        if (value >= 95){
            temp = 25;
        }
        else{
            temp = parseInt(value * 5 / 9 - 250 / 9); //95% -> 25 pts, 50% -> 0 pt
        }
        if(temp < 0){
            return 0;
        }
        else{
            return parseInt(temp);
        }
    };
    //Calcule du delay de pénalité 2pts/% apres 10 jours de retard.
    delaysPenalty = function (value) {
        if (value > 5) {
            return -10
        }
        else {
            return parseInt(value * -2)
        }    
    };
    //Calcule de nombre de point pour la qualité de livraison
    deliveryQuality = function (value) {
        if (value == 0) {
            return 2 //Retour 2pts si pas d'accident de livraison
        }
        else {
            return 0
        }
    };
    //Calcule le taux de service avec les pénalité
    tauxServiceAvecPenalite = function (targetRatePoint, firmOrderPoint) {
        var temp
        temp = parseInt((targetRatePoint * 5 * (1 + (firmOrderPoint / 100))) / 9 - (250 / 9));
        if (temp > 25) {
            temp = 25;
        }
        if (temp < 0) {
            return 0;
        }
        else {
            return parseInt(temp);
        }
    };
})(jQuery)